import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from "@angular/common/http";
import { Inject, Injectable } from "@angular/core";
import { Observable } from "rxjs/internal/Observable";
import { AuthService } from "../_services/auth.service";

@Injectable()
export class JwtInterceptor implements HttpInterceptor {

  baseUrl: string;

  constructor(
    private authService: AuthService,
    @Inject('BASE_URL') baseUrl: string
  ) {
    this.baseUrl = baseUrl;
  }

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    
    if (request.url.indexOf(`auth/login`) >= 0) {
      return next.handle(request);
    }

    request = request.clone({
      setHeaders: {
        Authorization: `Bearer ${this.authService.token}`
      }
    });

    return next.handle(request);
  }
}
