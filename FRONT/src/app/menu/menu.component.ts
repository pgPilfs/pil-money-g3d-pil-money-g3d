import { Component, OnInit } from '@angular/core';
import { DatosUsuarioService } from '../Services/datos-usuario.service';
import {ScriptServiceService} from './../Services/script-service.service';
import { Router } from '@angular/router';
import { HttpHeaders } from '@angular/common/http';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.css']
})
export class MenuComponent implements OnInit {
  public usuario:any;
  constructor(private _CargarScript:ScriptServiceService,private datousuario:DatosUsuarioService,private router:Router) { 
    _CargarScript.Carga(["script"]);
    var headers_object = new HttpHeaders().set("Authorization", "Bearer " + localStorage.getItem("jwt"));
  }

  ngOnInit(): void {
    const id: string = localStorage.getItem('idusuario')||'';
    if(id!=''){
      this.datousuario.ObtenerDatos(parseInt(id)).subscribe(
        data=> {
          console.log(data);
          this.usuario=data;
        }
      );
    }else{
      this.router.navigateByUrl('404');
    }
    

  }

  logout(){
    localStorage.clear();
    this.router.navigate(['login']);
   
  }
}
