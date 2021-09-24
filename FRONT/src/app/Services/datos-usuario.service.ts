import { HttpClientModule } from '@angular/common/http';
import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import { Usuario } from '../Models/Usuario';
import { Observable } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class DatosUsuarioService {
  readonly baseURL='https://localhost:44331/api/usuario';
  readonly urlcuenta='https://localhost:44331/api/cuenta'
  constructor(private http:HttpClient) {




   }


ObtenerDatos(id:number){
    
  const idu= id.toString();
  return this.http.get<any>(this.baseURL+"?id="+idu);
}

obtenercuenta(id:number):Observable<any>{
  const idu= id.toString();
  return this.http.get<any>(this.urlcuenta+"?id="+idu);
}

modifiedUser(userObj:any, id:number){
  return this.http.put(this.baseURL+"?id="+id,userObj);
}
}
