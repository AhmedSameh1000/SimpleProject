import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  constructor(private httpclient: HttpClient) {}

  LogIn(logInModel: any) {
    return this.httpclient.post(
      'https://localhost:7186/api/Auth/LogIn',
      logInModel
    );
  }
  GetData() {
    return this.httpclient.get('https://localhost:7186/api/Auth/SecureData');
  }
  Signup(SignupModel: any) {
    return this.httpclient.post(
      'https://localhost:7186/api/Auth/Register',
      SignupModel
    );
  }

  isLoggedIn() {
    if (
      localStorage.getItem('token') != null &&
      localStorage.getItem('token') != undefined
    ) {
      return true;
    }
    return false;
  }
  RefreshToken(userId: any) {
    return this.httpclient.post(
      `https://localhost:7186/api/Auth/RefreshToken?userId=${userId}`,
      {}
    );
  }
  SaveTokens(response: any) {
    localStorage.setItem('token', response.data.token);
  }

  GetToken() {
    return localStorage.getItem('token');
  }
  logout() {
    localStorage.removeItem('token');
  }
}
