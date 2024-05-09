/* tslint:disable */
/* eslint-disable */
import { HttpClient, HttpContext, HttpResponse } from '@angular/common/http';
import { Observable } from 'rxjs';
import { filter, map } from 'rxjs/operators';
import { StrictHttpResponse } from '../../strict-http-response';
import { RequestBuilder } from '../../request-builder';

import { PassengerRm } from '../../models/passenger-rm';

export interface FindPassenger$Plain$Params {
  email: string;
}

export function findPassenger$Plain(http: HttpClient, rootUrl: string, params: FindPassenger$Plain$Params, context?: HttpContext): Observable<StrictHttpResponse<PassengerRm>> {
  const rb = new RequestBuilder(rootUrl, findPassenger$Plain.PATH, 'get');
  if (params) {
    rb.path('email', params.email, {});
  }

  return http.request(
    rb.build({ responseType: 'text', accept: 'text/plain', context })
  ).pipe(
    filter((r: any): r is HttpResponse<any> => r instanceof HttpResponse),
    map((r: HttpResponse<any>) => {
      return r as StrictHttpResponse<PassengerRm>;
    })
  );
}

findPassenger$Plain.PATH = '/Passenger/{email}';
