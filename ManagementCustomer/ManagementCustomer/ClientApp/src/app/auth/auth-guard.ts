import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, CanActivateChild, Router, RouterStateSnapshot } from '@angular/router';
import { AuthService } from '../_services/auth.service';

@Injectable({ providedIn: 'root' })
export class AuthGuard implements CanActivate, CanActivateChild {

  constructor(
    private router: Router,
    private authService: AuthService
  ) { }

  async canActivate(activatedRoute: ActivatedRouteSnapshot, state: RouterStateSnapshot) {

    const token = this.authService.token;

    if (!token) {
      this.router.navigate(['/signin']);
      return false;
    }

    return true;
  }

  async canActivateChild(childRoute: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
    return await this.canActivate(childRoute, state);
  }
}


