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
  constructor(private datousuario:DatosUsuarioService, private fb: FormBuilder, private toast:ToastrService) { }

  ngOnInit(): void {
    this.getData();
    
  }
  getData = (): void => {
    this.datousuario.ObtenerDatos(2).subscribe(
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
    
    this.datousuario.modifiedUser(this.usuarioForm.value, 2).subscribe(data=>{
      this.toast.success('Datos Modificados con exito')
      console.log(data)
    }, err =>{
      this.toast.error(err)
      console.log(err);
    
    })
  }

}
