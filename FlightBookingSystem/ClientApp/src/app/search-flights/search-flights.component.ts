import { Time } from '@angular/common';
import { Component } from '@angular/core';

@Component({
  selector: 'app-search-flights',
  templateUrl: './search-flights.component.html',
  styleUrls: ['./search-flights.component.css']
})
export class SearchFlightsComponent {

  searchResult: FlightRm[] = [
    {
      airline: "American Airlines",
      remainingNumberOfSeats: 500,
      arrival: { time: Date.now().toString(), place: "Istanbul" },
      departure: { time: Date.now().toString(), place: "Los Angeles" },
      price: "350"
    },
    {
      airline: "Delta",
      remainingNumberOfSeats: 60,
      arrival: { time: Date.now().toString(), place: "Las Vegas" },
      departure: { time: Date.now().toString(), place: "San Antonio" },
      price: "350"
    },
    {
      airline: "Frontier",
      remainingNumberOfSeats: 500,
      arrival: { time: Date.now().toString(), place: "San Diego" },
      departure: { time: Date.now().toString(), place: "New York" },
      price: "650"
    }
  ]

}

export interface FlightRm {
  airline: string;
  arrival: TimePlaceRm;
  departure: TimePlaceRm;
  price: string;
  remainingNumberOfSeats: number;
}

export interface TimePlaceRm {
  place: string;
  time: string;
}
