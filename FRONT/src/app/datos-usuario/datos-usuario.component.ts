import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { DatosUsuarioService } from '../Services/datos-usuario.service';

@Component({
  selector: 'app-datos-usuario',
  templateUrl: './datos-usuario.component.html',
  styleUrls: ['./datos-usuario.component.css']
})
export class DatosUsuarioComponent implements OnInit {
  usuario!:any;
  usuarioForm!: FormGroup;
  constructor(private datousuario:DatosUsuarioService, private fb: FormBuilder) { }

  ngOnInit(): void {
    this.getData();
    this.usuarioForm = this.fb.group({
      Nombre: [],
      Apelldio: [],
      Email: [ ],
      Pais:[],
      Telefono:[],
      Provincia:[],
      Ciudad:[],
      Calle:[],
      Dni:[],
      NombreUsuario:[],
      Password:[]
    })
  }

  getData(){
    this.datousuario.ObtenerDatos(2).subscribe(
      data=> {
        console.log(data);
       this.usuario=data;
      }
    );
  }

  modificarUsuario(){
    this.datousuario.modifiedUser(this.usuarioForm.value, 2).subscribe(data=>{
      console.log("Modificado")
      console.log(data)
    }, err =>{
  
      console.log(err);
    
    })
  }

}
