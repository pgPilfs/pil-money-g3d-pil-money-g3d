import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';

import { RegistroComponent } from './registro/registro.component';

import { LandingComponent } from './landing/landing.component';
import { FooterComponent } from './footer/footer.component';
import { HeaderComponent } from './header/header.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { TransferenciaComponent } from './transferencia/transferencia.component';


@NgModule({
  declarations: [
    AppComponent,


    RegistroComponent,

    LandingComponent,
    FooterComponent,
    HeaderComponent,


    LoginComponent,
        TransferenciaComponent

  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
