import { Time } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { FlightService } from '../api/services/flight.service';
import { FlightRm } from '../api/models'

@Component({
  selector: 'app-search-flights',
  templateUrl: './search-flights.component.html',
  styleUrls: ['./search-flights.component.css']
})
export class SearchFlightsComponent implements OnInit {

  searchResult: FlightRm[] = [];

  constructor(private flightService: FlightService) { }

  ngOnInit() {

  }

  search() {
    this.flightService.searchFlight({}).subscribe(request => this.searchResult = request, this.handleError)
  }

  private handleError(err: any) {
    console.log(err)
  }

}
