import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import {
  FormGroup,
 FormBuilder,

 FormControl,
 Validators
} from '@angular/forms';
import { data } from 'jquery';
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
    private userService:RegistroService
    ) { }

  ngOnInit(): void {
    this.registerform();
    
    // this.registroDatos();
  }

  registerform():void{
    this.registroForm= this.fb.group({
      nombreusuario: new FormControl('',Validators.required),
      nombre: new FormControl('', [Validators.required, Validators.pattern('^[a-zA-Z]+$')]),
      apellido: new FormControl('',[Validators.required, Validators.pattern('^[a-zA-Z]+$')]),
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
  // console.log(this.registroForm.value)
  this.userService.addUser(this.registroForm.value).subscribe(data=>{
    console.log("Creado")
  }, err =>{

    console.log(err);
  
  })
}



}
