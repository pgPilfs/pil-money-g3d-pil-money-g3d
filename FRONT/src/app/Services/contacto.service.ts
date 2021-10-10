import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ContactoService {
  readonly urlcontact= "https://localhost:44331/api/contacto";
  constructor(private http:HttpClient) { }

  ObtenerContactos(id:number){
    
    const idu= id.toString();
    return this.http.get<any>(this.urlcontact+"?id="+idu);
  }
}
