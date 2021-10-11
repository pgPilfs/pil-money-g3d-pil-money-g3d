import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class LoginService {
  readonly loginurl='https://localhost:44331/api/login';
  constructor(private http:HttpClient) { }


  loginpost(credenciales:any){
    return this.http.post(this.loginurl,credenciales);
  }



}
