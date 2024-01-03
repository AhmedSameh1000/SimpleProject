import { Component } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent {
  constructor(private AuthService: AuthService, private Router: Router) {}
  ngOnInit(): void {
    this.CreatelogInForm();
  }
  LoginForm: FormGroup;

  CreatelogInForm() {
    this.LoginForm = new FormGroup({
      Email: new FormControl(null, [Validators.required, Validators.email]),
      Password: new FormControl(null, [Validators.required]),
    });
  }
  Login() {
    if (this.LoginForm.invalid) {
      return;
    }
    this.AuthService.LogIn(this.LoginForm.value).subscribe({
      next: (res: any) => {
        this.AuthService.SaveTokens(res);
        this.Router.navigate(['']);
        console.log(res.data.token);
      },
      error: (err) => {
        console.log(err);
      },
    });
  }
}
