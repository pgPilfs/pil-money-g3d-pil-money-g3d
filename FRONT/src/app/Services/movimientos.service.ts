import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class MovimientosService {
readonly urlmov= "https://localhost:44331/api/operaciones";
  constructor(private http:HttpClient) { }



  ObtenerMovimientos(id:number){
    
    const idu= id.toString();
    return this.http.get<any>(this.urlmov+"?idcuenta="+idu);
  }
  Operaciones(objet:any){
    return this.http.post<any>(this.urlmov,objet);
  }

  OperacionesCuenta(cvu:string,objet:any){
    return this.http.post<any>(this.urlmov+"?cvu="+cvu,objet);
  }
}
