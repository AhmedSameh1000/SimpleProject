import { Component } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],
})
export class RegisterComponent {
  constructor(private AuthService: AuthService, private Router: Router) {}
  ngOnInit(): void {
    this.CreatelogInForm();
  }
  ReegisterForm: FormGroup;

  CreatelogInForm() {
    this.ReegisterForm = new FormGroup({
      FullName: new FormControl('', [Validators.required]),
      Email: new FormControl('', [Validators.required, Validators.email]),
      Password: new FormControl('', [Validators.required]),
    });
  }
  isLreadySigned: string;
  Register() {
    if (this.ReegisterForm.invalid) {
      return;
    }
    this.AuthService.Signup(this.ReegisterForm.value).subscribe({
      next: (res: any) => {
        this.AuthService.SaveTokens(res);
        this.Router.navigate(['auth/login']);
      },
      error: (err) => {
        console.log(err.error.message);
      },
    });
  }
}
