import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { City } from '../models/city.model';
import { Classification } from '../models/classification.model';
import { Customer } from '../models/customer.model';
import { Gender } from '../models/gender.model';
import { Region } from '../models/region.model';
import { User } from '../models/user.model';
import { AddressService } from '../_services/address.service';
import { AuthService } from '../_services/auth.service';
import { ClassificationService } from '../_services/classification.service';
import { CustomerService } from '../_services/customer.service';
import { GenderService } from '../_services/gender.service';
import { UserService } from '../_services/user.service';

@Component({
  selector: 'app-customers-component',
  templateUrl: './customers.component.html'
})
export class CustomersComponent implements OnInit {

  customers: Customer[];
  genders: Gender[];
  regions: Region[];
  cities: City[];
  classifications: Classification[];
  users: User[];

  form: FormGroup;

  get isAdmin() {
    return this.authService.is_admin;
  }

  constructor(
    private customerService: CustomerService,
    private addressService: AddressService,
    private classificationService: ClassificationService,
    private genderService: GenderService,
    private userService: UserService,
    private authService: AuthService,
    private formBuilder: FormBuilder,
  ) {
    this.form = this.formBuilder.group({
      name: [],
      genderId: [],
      cityId: [],
      regionId: [],
      lastPurchaseFrom: [],
      lastPurchaseUntil: [],
      classificationId: [],
      userId: [],
    });
  }

  ngOnInit(): void {
    this.getCustomerList();
    this.getGenderList();
    this.getRegionList();
    this.getClassificationList();
    this.getUserList();

    this.form.get('regionId').valueChanges
      .subscribe((regionId: number) => {
        this.cities = [];
        if (!!regionId) {
          this.getCityList(regionId);
        }
      });
  }

  submit() {
    if (this.form.invalid) {
      return;
    }

    const data = this.form.getRawValue();

    this.customerService.getCustomerFilter(
      data.name,
      data.genderId,
      data.cityId,
      data.regionId,
      data.lastPurchaseFrom,
      data.lastPurchaseUntil,
      data.classificationId,
      data.userId
    )
      .subscribe(result => {
        this.customers = result;
      });
  }

  public getCustomerList() {
    this.customerService.getCustomerList()
      .subscribe(result => {

        this.customers = result;

      }, error => console.error(error))
  }

  public getGenderList() {
    this.genderService.getList()
      .subscribe(result => {

        this.genders = result;

      }, error => console.error(error))
  }

  public getRegionList() {
    this.addressService.getRegionList()
      .subscribe(result => {

        this.regions = result;

      }, error => console.error(error))
  }

  public getCityList(regionId: number) {
    this.addressService.getCityList(regionId)
      .subscribe(result => {

        this.cities = result;

      }, error => console.error(error))
  }

  public getClassificationList() {
    this.classificationService.getList()
      .subscribe(result => {

        this.classifications = result;

      }, error => console.error(error))
  }

  public getUserList() {
    this.userService.getList()
      .subscribe(result => {

        this.users = result;

      }, error => console.error(error))
  }

  public clearForm() {
    this.form.reset();
  }
}
