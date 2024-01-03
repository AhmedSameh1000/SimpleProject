import { inject } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../services/auth.service';

export const CanActivate = () => {
  let authService = inject(AuthService);
  let router = inject(Router);
  if (authService.IsAdmin()) {
    return true;
  } else {
    router.navigate(['']);
    return false;
  }
};
