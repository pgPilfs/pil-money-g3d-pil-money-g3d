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
    
  const idu= id.toString();
return this.http.get<any>(this.baseURL+"?id="+idu);
}
}
