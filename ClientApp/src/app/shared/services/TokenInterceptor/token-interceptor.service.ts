import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent, HttpErrorResponse } from '@angular/common/http';
import { Observable } from 'rxjs';
import { AuthenticationService } from 'src/app/shared/services/authentication/authentication.service';
@Injectable({
  providedIn: 'root'
})
export class TokenInterceptorService implements HttpInterceptor {
  constructor(private authService: AuthenticationService) { }

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    request = this.addToken(request, this.authService.getJwtToken());
        return next.handle(request).pipe();

  }

  private addToken(request: HttpRequest<any>, token: string) {
    request = request.clone({
      withCredentials: true
  });
    return request.clone({
      setHeaders: {
        'Authorization': `Bearer ${token}`,
      },
    });
  }
}