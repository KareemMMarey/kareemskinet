import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { Router, NavigationExtras } from '@angular/router';
import { Injectable } from '@angular/core';
import { catchError, delay, finalize } from 'rxjs/operators';
import { error } from 'protractor';
import { ToastrService } from 'ngx-toastr';
import { BusyService } from '../services/busy.service';

@Injectable()
export class LoadingInterceptors implements HttpInterceptor{
    constructor(private busyService: BusyService, private toastr: ToastrService)
    {}

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
       this.busyService.busy();
       return next.handle(req).pipe(
        // delay the app response to add loader
        delay(1000),
        finalize(() => {
            this.busyService.idle();
        }));
    }
}
