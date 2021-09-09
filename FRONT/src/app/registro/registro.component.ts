import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import {
  FormGroup,
 FormBuilder,

 FormControl,
 Validators
} from '@angular/forms';
import { data } from 'jquery';
import { RegistroService } from '../registro.service';
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
  }

  registerform():void{
    this.registroForm= this.fb.group({
      nombreusuario: new FormControl (''),
      email: new FormControl(''),
      password:new FormControl(''),
    });
  }


//   initializeForm(): void {
//     this.registroForm = this.fb.group({
//         name: ['', [Validators.required, Validators.pattern('^[a-zA-Z]+$')]],
//         surname:['', [Validators.required,Validators.pattern('^[a-zA-Z]+$') ]],
//         email:new FormControl('', [Validators.required, Validators.email]),
//         phoneNumber: ['', [Validators.required, Validators.pattern("[0-9]{10}")]],
//         phoneNumber2:['', [Validators.required, Validators.pattern("[0-9]{10}")]],
//         address: ['', Validators.required],
//         address2: ['', Validators.required],
//         city: ['', Validators.required],
//         provincia: ['', Validators.required],
//         termsYcond: [false, Validators.required],
//         password:['', [
//           Validators.required,
//           // Validators.pattern(/^(?=\D*\d)(?=[^a-z]*[a-z])(?=[^A-Z]*[A-Z]).{8,30}$/)
//         ]]
    
//     });

// }

onSubmit(){
  this.userService.addUser(this.registroForm.value).subscribe(data=>{
    console.log("Usuario creado")
  }, err =>{

    console.log(err);
  
  })
}


}
