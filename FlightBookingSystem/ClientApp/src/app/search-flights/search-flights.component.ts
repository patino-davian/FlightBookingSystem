import { Time } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { FlightService } from '../api/services/flight.service';
import { FlightRm } from '../api/models';
import { FormBuilder } from '@angular/forms';
import { SearchFlightParams } from '../../interfaces/search-flight-params'

@Component({
  selector: 'app-search-flights',
  templateUrl: './search-flights.component.html',
  styleUrls: ['./search-flights.component.css']
})
export class SearchFlightsComponent implements OnInit {

  searchResult: FlightRm[] = [];

  constructor(
    private flightService: FlightService,
    private formBuilder: FormBuilder) { }

  searchForm = this.formBuilder.group({
    from: [''],
    destination: [''],
    fromDate: [''],
    toDate: [''],
    numberOfPassengers: [1]
  })

  ngOnInit(): void {
    this.search();
  }

  search() {

    const formValues = this.searchForm.value;

    const params: SearchFlightParams = {
      from: formValues.from || '',
      destination: formValues.destination || '',
      fromDate: formValues.fromDate || '',
      toDate: formValues.toDate || '',
      numberOfPassengers: formValues.numberOfPassengers ?? 1
    }

    this.flightService.searchFlight(params)
      .subscribe(request => {
        this.searchResult = request;
      },
    error => this.handleError)
  }

  private handleError(err: any) {
    console.log("Response Error. Status: ", err.status)
    console.log("Response Error. Status Text: ", err.statusText)
    console.log(err)
  }

}
