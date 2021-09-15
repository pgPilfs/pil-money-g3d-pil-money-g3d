import { Component, OnInit } from '@angular/core';
import { DatosUsuarioService } from '../Services/datos-usuario.service';

@Component({
  selector: 'app-inicio',
  templateUrl: './inicio.component.html',
  styleUrls: ['./inicio.component.css']
})
export class InicioComponent implements OnInit {

  constructor(private datousuario:DatosUsuarioService) { }

  ngOnInit(): void {
    this.datousuario.ObtenerDatos(2).subscribe(
      data=> {
        console.log(data);
        this.usuario=data;
      }
    );
  }

}
