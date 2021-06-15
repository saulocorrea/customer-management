import { HttpClient } from "@angular/common/http";
import { Inject, Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { Customer } from "../models/customer.model";

@Injectable({ providedIn: 'root' })
export class CustomerService {

  baseUrl: string;

  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string
  ) {
    this.baseUrl = baseUrl;
  }

  getCustomerList(): Observable<Customer[]> {
    return this.http.get<Customer[]>(`${this.baseUrl}customer/list`);
  }

  getCustomerFilter(
    name: string,
    genderId: number,
    cityId: number,
    regionId: number,
    lastPurchaseFrom: Date,
    lastPurchaseUntil: Date,
    classificationId: number,
    userId: number,
  ): Observable<Customer[]> {

    genderId = !!genderId ? +genderId : null;
    cityId = !!cityId ? +cityId : null;
    regionId = !!regionId ? +regionId : null;
    classificationId = !!classificationId ? +classificationId : null;
    userId = !!userId ? +userId : null;

    const params = {
      name,
      genderId,
      cityId,
      regionId,
      lastPurchaseFrom,
      lastPurchaseUntil,
      classificationId,
      userId
    }

    return this.http.post<Customer[]>(`${this.baseUrl}customer/find`, params);
  }
}
