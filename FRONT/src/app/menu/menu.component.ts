import { Component, OnInit } from '@angular/core';
import { Usuario } from '../Models/Usuario';
import { DatosUsuarioService } from '../Services/datos-usuario.service';
import {ScriptServiceService} from './../Services/script-service.service'

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.css']
})
export class MenuComponent implements OnInit {
  public usuario:any;
  constructor(private _CargarScript:ScriptServiceService,private datousuario:DatosUsuarioService) { 
    _CargarScript.Carga(["script"]);
  }

  ngOnInit(): void {
    this.datousuario.ObtenerDatos(2).subscribe(
      data=> {
        console.log(data);
        this.usuario=data;
      }
    );

  }

}
