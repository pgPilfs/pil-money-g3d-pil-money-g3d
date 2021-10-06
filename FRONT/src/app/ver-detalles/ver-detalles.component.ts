import { Component, OnInit } from '@angular/core';
import { DatosUsuarioService } from '../Services/datos-usuario.service';

@Component({
  selector: 'app-ver-detalles',
  templateUrl: './ver-detalles.component.html',
  styleUrls: ['./ver-detalles.component.css']
})
export class VerDetallesComponent implements OnInit {
  public usuario:any;
  public datosusuario:any;
  constructor(private datousuario:DatosUsuarioService) { }

  ngOnInit(): void {
    const id: string = localStorage.getItem('idusuario')||'';
    this.datousuario.obtenercuenta(parseInt(id)).subscribe(
      data=> {
        console.log(data);
        this.usuario=data;
      }
    );
  }

}
