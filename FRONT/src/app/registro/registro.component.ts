import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import {
  FormGroup,
 FormBuilder,

 FormControl,
 Validators
} from '@angular/forms';
import { data } from 'jquery';
import { ToastrService } from 'ngx-toastr';
import { RegistroService } from '../Services/registro.service';
import { Usuario } from '../usuario';

@Component({
  selector: 'app-registro',
  templateUrl: './registro.component.html',
  styleUrls: ['./registro.component.css']
})
export class RegistroComponent implements OnInit {
  registroForm!: FormGroup;
  usuario!:Usuario;
  constructor(
    private fb: FormBuilder,
    private userService:RegistroService,
    private toastr: ToastrService
    ) { }

  ngOnInit(): void {
    this.registerform();
  }

  registerform():void{
    this.registroForm= this.fb.group({
      nombreusuario: new FormControl('',Validators.required),
      nombre: new FormControl('', [Validators.required, Validators.pattern('^[a-zA-Z]+$')]),
      apelldio: new FormControl('',[Validators.required, Validators.pattern('^[a-zA-Z]+$')]),
      dni: new FormControl('',[Validators.required, Validators.pattern("[0-9]{8}")]),
      telefono: new FormControl('',[Validators.required, Validators.pattern("[0-9]{10}")]),
      email: new FormControl('',[Validators.required, Validators.email]),
      calle: new FormControl('',Validators.required),
      ciudad: new FormControl('',Validators.required),
      provincia: new FormControl('',Validators.required),
      pais: new FormControl('',Validators.required),
      password: new FormControl('',[Validators.required,Validators.pattern(/^(?=\D*\d)(?=[^a-z]*[a-z])(?=[^A-Z]*[A-Z]).{8,30}$/)])
    });
  }
  

onSubmit(){
  if(this.registroForm.valid){
    this.userService.addUser(this.registroForm.value).subscribe(data=>{
      this.toastr.success('Usuario Creado');
    }, err =>{
  
      this.toastr.error(err);
    
    })
  }
  else{
    this.registroForm.markAllAsTouched();
  }
}



}
