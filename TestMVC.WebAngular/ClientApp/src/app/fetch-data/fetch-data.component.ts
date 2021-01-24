import { Component } from '@angular/core';
import { EmployeeService } from '../services/employee.service';
import { Observable } from 'rxjs/Observable';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {

  public employees$: Observable<iemployee[]>;
  employeeId: number;
  employeeCount: number;
  error: boolean;
  constructor(private service: EmployeeService) {
  }
  
getEmployee() {
  this.employees$ = this.service.getEmployee(this.employeeId);
  this.employees$.subscribe(data => {
    this.employeeCount = data.length;
  });
}
}

export interface iemployee {
  id: number;
  name: string;
  contractTypeName: string;
  roleName: string;
  annualSalary: number;
}
