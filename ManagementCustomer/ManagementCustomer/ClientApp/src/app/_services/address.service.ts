import { HttpClient } from "@angular/common/http";
import { Inject, Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { City } from "../models/city.model";
import { Region } from "../models/region.model";

@Injectable({ providedIn: 'root' })
export class AddressService {

  baseUrl: string;

  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string
  ) {
    this.baseUrl = baseUrl;
  }

  getCityList(regionId: number): Observable<City[]> {
    return this.http.get<City[]>(`${this.baseUrl}address/list-cities?regionId=${regionId}`);
  }

  getRegionList(): Observable<Region[]> {
    return this.http.get<Region[]>(`${this.baseUrl}address/list-regions`);
  }
}
