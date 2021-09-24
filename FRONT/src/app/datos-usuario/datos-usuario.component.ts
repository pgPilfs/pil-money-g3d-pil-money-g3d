import { Component, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { DatosUsuarioService } from '../Services/datos-usuario.service';

@Component({
  selector: 'app-datos-usuario',
  templateUrl: './datos-usuario.component.html',
  styleUrls: ['./datos-usuario.component.css']
})
export class DatosUsuarioComponent implements OnInit {
  public usuario:any;
  usuarioForm!: FormGroup;
  constructor(private datousuario:DatosUsuarioService) { }

  ngOnInit(): void {
    this.datousuario.ObtenerDatos(2).subscribe(
      data=> {
        console.log(data);
        this.usuario=data;
      }
    );
  }

  onSubmit(){
    this.datousuario.modifiedUser(this.usuarioForm.value, 2).subscribe(data=>{
      console.log("Modificado")
    }, err =>{
  
      console.log(err);
    
    })
  }

}
