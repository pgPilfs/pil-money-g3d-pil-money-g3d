import { HttpHeaders } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Toast, ToastrService } from 'ngx-toastr';
import { IUser } from '../Interfaces/IUser';
import { DatosUsuarioService } from '../Services/datos-usuario.service';

@Component({
  selector: 'app-datos-usuario',
  templateUrl: './datos-usuario.component.html',
  styleUrls: ['./datos-usuario.component.css']
})
export class DatosUsuarioComponent implements OnInit {
  usuario!:any;
  usuarioForm!: FormGroup;

  constructor(private datousuario:DatosUsuarioService, private fb: FormBuilder,private toastr: ToastrService) { 
    var headers_object = new HttpHeaders().set("Authorization", "Bearer " + localStorage.getItem("jwt"));


  }

  ngOnInit(): void {
    this.getData();
    
  }
  getData = (): void => {
    const id: string = localStorage.getItem('idusuario')||'';
    this.datousuario.ObtenerDatos(parseInt(id)).subscribe(
        (response: any) => {
            
            this.initForm(response);
        },
        (error: any) => {
            console.log(error);
        },
        () => {}
     );
}

initForm(data:any){
  
  this.usuario=data;
  this.usuarioForm = this.fb.group({
  nombre: [data.nombre],
  apelldio: [data.apelldio],
  email: [data.email],
  pais:[data.pais,],
  telefono:[data.telefono],
  provincia:[data.provincia],
  ciudad:[data.ciudad],
  calle:[data.calle],
  dni:[data.dni],
  nombreUsuario: [data.nombreUsuario],
  password: [data.password]
  })
      
}

  modificarUsuario(){
    const id = localStorage.getItem('idusuario')||'';
    this.datousuario.modifiedUser(this.usuarioForm.value,parseInt(id)).subscribe(data=>{
      this.toastr.success('Datos Actualizados');
    }, err =>{
      this.toastr.error(err);
    })
  }

}
