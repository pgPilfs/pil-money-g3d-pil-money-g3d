import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { Observable } from 'rxjs';
import { Usuario } from './usuario';

@Injectable({
  providedIn: 'root'
})
export class RegistroService {
  readonly baseURL='https://localhost:44371/api/usuario';
  constructor(private http:HttpClient) { 
  }



  addUser(userObj:any){
    return this.http.post(this.baseURL,userObj);
  }
}
