import { TestBed } from '@angular/core/testing';

import { EmployeejwtinterceptorInterceptor } from './employeejwtinterceptor.interceptor';

describe('EmployeejwtinterceptorInterceptor', () => {
  beforeEach(() => TestBed.configureTestingModule({
    providers: [
      EmployeejwtinterceptorInterceptor
      ]
  }));

  it('should be created', () => {
    const interceptor: EmployeejwtinterceptorInterceptor = TestBed.inject(EmployeejwtinterceptorInterceptor);
    expect(interceptor).toBeTruthy();
  });
});
