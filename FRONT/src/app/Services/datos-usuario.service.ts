import { HttpClientModule } from '@angular/common/http';
import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import { Usuario } from '../Models/Usuario';
@Injectable({
  providedIn: 'root'
})
export class DatosUsuarioService {
  readonly baseURL='https://localhost:44331/api/usuario';
  constructor(private http:HttpClient) {




   }


ObtenerDatos(id:number){
return this.http.get<Usuario>(this.baseURL+"/"+id.toString());
}
}
