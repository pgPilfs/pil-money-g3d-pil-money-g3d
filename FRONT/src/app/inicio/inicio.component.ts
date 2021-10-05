import { Component, OnInit } from '@angular/core';
import { DatosUsuarioService } from '../Services/datos-usuario.service';

@Component({
  selector: 'app-inicio',
  templateUrl: './inicio.component.html',
  styleUrls: ['./inicio.component.css']
})
export class InicioComponent implements OnInit {
  public usuario:any;
  public datosusuario:any;
  constructor(private datousuario:DatosUsuarioService) { }

  ngOnInit(): void {
    this.datousuario.obtenercuenta(11).subscribe(
      data=> {
        console.log(data);
        this.usuario=data;
      }
    );

    this.datousuario.ObtenerDatos(11).subscribe(
      datos=> {
        console.log(datos);
        this.datosusuario=datos;
      }
    );
  }

}
