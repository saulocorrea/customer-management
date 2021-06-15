import { HttpClient } from "@angular/common/http";
import { Inject, Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { Classification } from "../models/classification.model";

@Injectable({ providedIn: 'root' })
export class ClassificationService {

  baseUrl: string;

  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string
  ) {
    this.baseUrl = baseUrl;
  }

  getList(): Observable<Classification[]> {
    return this.http.get<Classification[]>(`${this.baseUrl}classification/list`);
  }
}
