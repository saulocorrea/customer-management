import { Component, OnInit } from '@angular/core';
import { Customer } from '../models/customer.model';
import { AuthService } from '../_services/auth.service';
import { CustomerService } from '../_services/customer.service';

@Component({
  selector: 'app-customers-component',
  templateUrl: './customers.component.html'
})
export class CustomersComponent implements OnInit {

  customers: Customer[];

  constructor(
    private customerService: CustomerService,
    private authService: AuthService
  ) { }

  ngOnInit(): void {
    this.getCustomerList();
  }

  get isAdmin() {
    return this.authService.is_admin;
  }

  public getCustomerList() {
    this.customerService.getCustomerList()
    .subscribe(result => {

      this.customers = result;

    }, error => console.error(error))
  }
}
