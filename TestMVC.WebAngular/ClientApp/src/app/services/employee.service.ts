import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { error } from 'protractor';
import { Observable } from 'rxjs/Observable';
import { iemployee } from '../fetch-data/fetch-data.component';


@Injectable()
export class EmployeeService {

  constructor(private http: HttpClient) {
  }

  getEmployee(id?: number): Observable<iemployee[]>  {
    var route = "/api/Employee";
    if (id) {
      route = "/api/Employee/" + id;
    }
    return this.http.get<iemployee[]>(route);
  }

}
