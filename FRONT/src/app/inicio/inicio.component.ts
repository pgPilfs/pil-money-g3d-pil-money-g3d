import { HttpHeaders } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { DatosUsuarioService } from '../Services/datos-usuario.service';
import { Router } from '@angular/router';
import { MovimientosService } from '../Services/movimientos.service';

@Component({
  selector: 'app-inicio',
  templateUrl: './inicio.component.html',
  styleUrls: ['./inicio.component.css']
})
export class InicioComponent implements OnInit {
  public usuario:any;
  public datosusuario:any;
  public inmu: any;
  constructor(private datousuario:DatosUsuarioService, private router:Router, private mov:MovimientosService) { 
    var headers_object = new HttpHeaders().set("Authorization", "Bearer " + localStorage.getItem("jwt"));
  }

  ngOnInit(): void {
    const id: string = localStorage.getItem('idusuario')||'';
    
      this.datousuario.obtenercuenta(parseInt(id)).subscribe(
        data=> {
          this.usuario=data;
          
        },err=>{
         
        }
      );
  
      this.datousuario.ObtenerDatos(parseInt(id)).subscribe(
        datos=> {
          this.datosusuario=datos;
        }
      );
      const idcuenta: string = localStorage.getItem('idcuenta')||'';
      this.mov.ObtenerMovimientos(parseInt(idcuenta)).subscribe(mov=>{

        this.inmu = mov; 
      });
    
   

    
  }
isUserAuthenticated(){
  const token: string = localStorage.getItem('jwt')||'';
  if(token)
  {
    return true;
  }
  else
  {
    return false;
  }
}
}
