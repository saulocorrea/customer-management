import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Customer } from '../models/customer.model';
import { LoginToken } from '../models/login-token.model';
import { AuthService } from '../_services/auth.service';

@Component({
  selector: 'app-login-component',
  templateUrl: './login.component.html'
})
export class LoginComponent {

  customers: Customer[];

  form: FormGroup;
  hasError = false;

  constructor(
    private authService: AuthService,
    private router: Router,
    private formBuilder: FormBuilder,
  ) {
    this.form = this.formBuilder.group({
      email: [null, [Validators.required]],
      password: [null, [Validators.required]]
    });
  }

  public submit() {
    if (!this.form.valid) {
      return;
    }

    this.hasError = false;

    const email = this.form.get('email').value;
    const password = this.form.get('password').value;

    this.authService.login(email, password)
      .subscribe((result: LoginToken) => {

        if (!!result && !!result.token) {
          this.authService.setToken(result);
          this.router.navigate(['/customers']);
        } else {
          this.hasError = true;
        }

      }, error => console.error(error));
  }
}
