import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';
import { NgxMaskModule } from 'ngx-mask';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { ApiAuthorizationModule } from 'src/api-authorization/api-authorization.module';
import { AuthorizeGuard } from 'src/api-authorization/authorize.guard';
import { AuthorizeInterceptor } from 'src/api-authorization/authorize.interceptor';
import { HabitacionesComponent } from './habitaciones/habitaciones.component';
import { HuespedComponent } from './huesped/huesped.component';
import { ReservacionComponent } from './reservacion/reservacion.component';
import { HabitacionService } from './services/habitacion.service';
import { HuespedService } from './services/huesped.service';
import { ReservacionService } from './services/reservacion.service';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    HabitacionesComponent,
    HuespedComponent,
    ReservacionComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    ApiAuthorizationModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent, canActivate: [AuthorizeGuard] },
      { path: 'huesped', component: HuespedComponent, canActivate: [AuthorizeGuard] },
      { path: 'habitaciones', component: HabitacionesComponent, canActivate: [AuthorizeGuard] },
    ]),
    ToastrModule.forRoot({ enableHtml: true, timeOut: 3000, preventDuplicates: true }),
    NgxMaskModule.forRoot(),
    BrowserAnimationsModule
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: AuthorizeInterceptor, multi: true },
    HabitacionService,
    HuespedService,
    ReservacionService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
