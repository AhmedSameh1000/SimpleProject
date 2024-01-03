import { TestBed } from '@angular/core/testing';

import { AuthrefreshtokenInterceptor } from './authrefreshtoken.interceptor';

describe('AuthrefreshtokenInterceptor', () => {
  beforeEach(() => TestBed.configureTestingModule({
    providers: [
      AuthrefreshtokenInterceptor
      ]
  }));

  it('should be created', () => {
    const interceptor: AuthrefreshtokenInterceptor = TestBed.inject(AuthrefreshtokenInterceptor);
    expect(interceptor).toBeTruthy();
  });
});
