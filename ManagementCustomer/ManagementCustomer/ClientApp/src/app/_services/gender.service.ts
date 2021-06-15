import { HttpClient } from "@angular/common/http";
import { Inject, Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { Gender } from "../models/gender.model";

@Injectable({ providedIn: 'root' })
export class GenderService {

  baseUrl: string;

  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string
  ) {
    this.baseUrl = baseUrl;
  }

  getList(): Observable<Gender[]> {
    return this.http.get<Gender[]>(`${this.baseUrl}gender/list`);
  }
}
