import { Component, OnInit } from '@angular/core';
import { DatosUsuarioService } from '../Services/datos-usuario.service';

@Component({
  selector: 'app-ver-detalles',
  templateUrl: './ver-detalles.component.html',
  styleUrls: ['./ver-detalles.component.css']
})
export class VerDetallesComponent implements OnInit {
  public usuario:any;
  constructor(private datousuario:DatosUsuarioService) { }

  ngOnInit(): void {
    this.datousuario.obtenercuenta(2).subscribe(
      data=> {
        console.log(data);
        this.usuario=data;
      }
    );
  }

}
