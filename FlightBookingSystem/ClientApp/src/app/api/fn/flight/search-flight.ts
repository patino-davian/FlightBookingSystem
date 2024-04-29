/* tslint:disable */
/* eslint-disable */
import { HttpClient, HttpContext, HttpResponse } from '@angular/common/http';
import { Observable } from 'rxjs';
import { filter, map } from 'rxjs/operators';
import { StrictHttpResponse } from '../../strict-http-response';
import { RequestBuilder } from '../../request-builder';

import { FlightRm } from '../../models/flight-rm';

export interface SearchFlight$Params {
}

export function searchFlight(http: HttpClient, rootUrl: string, params?: SearchFlight$Params, context?: HttpContext): Observable<StrictHttpResponse<Array<FlightRm>>> {
  const rb = new RequestBuilder(rootUrl, searchFlight.PATH, 'get');
  if (params) {
  }

  return http.request(
    rb.build({ responseType: 'json', accept: 'text/json', context })
  ).pipe(
    filter((r: any): r is HttpResponse<any> => r instanceof HttpResponse),
    map((r: HttpResponse<any>) => {
      return r as StrictHttpResponse<Array<FlightRm>>;
    })
  );
}

searchFlight.PATH = '/Flight';
