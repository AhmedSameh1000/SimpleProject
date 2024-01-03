import { Component } from '@angular/core';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
})
export class HomeComponent {
  constructor(private AuthService: AuthService) {}
  data = [];
  ngOnInit(): void {
    this.AuthService.GetData().subscribe({
      next: (res: any) => {
        console.log(res);
        this.data = res;
      },
    });
  }
}
