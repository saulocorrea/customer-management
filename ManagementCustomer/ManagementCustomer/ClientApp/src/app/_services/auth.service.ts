import { HttpClient } from "@angular/common/http";
import { Inject, Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { LoginToken } from "../models/login-token.model";

@Injectable({ providedIn: 'root' })
export class AuthService {

  token: string;
  baseUrl: string;

  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string
  ) {
    this.baseUrl = baseUrl;
  }

  login(email: string, password: string): Observable<LoginToken> {

    const params = {
      email,
      password
    }

    return this.http.post<LoginToken>(`${this.baseUrl}auth/login`, params);
  }

  get claims() {
    if (!this.token) {
      return {
        is_admin: "False"
      };
    }
    
    let decodedJWT = JSON.parse(window.atob(this.token.split('.')[1]));

    return decodedJWT;
  }

  get is_admin() {
    return this.claims.is_admin === "True";
  }

  get isAuthenticated() {
    return !!this.token;
  }

  public setToken(token: LoginToken) {
    this.token = token.token;
  }
}
