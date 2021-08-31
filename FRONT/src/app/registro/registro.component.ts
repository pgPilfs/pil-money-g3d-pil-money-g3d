import { Component, OnInit } from '@angular/core';
import {
  FormGroup,
 FormBuilder,

 FormControl,
 Validators
} from '@angular/forms';


@Component({
  selector: 'app-registro',
  templateUrl: './registro.component.html',
  styleUrls: ['./registro.component.css']
})
export class RegistroComponent implements OnInit {
  registroForm!: FormGroup;
  constructor(private fb: FormBuilder) { }

  ngOnInit(): void {
    this.initializeForm();
  }
  initializeForm(): void {
    this.registroForm = this.fb.group({
        name: ['', [Validators.required, Validators.pattern('^[a-zA-Z]+$')]],
        surname:['', [Validators.required,Validators.pattern('^[a-zA-Z]+$') ]],
        email:new FormControl('', [Validators.required, Validators.email]),
        phoneNumber: ['', [Validators.required, Validators.pattern("[0-9]{10}")]],
        phoneNumber2:['', [Validators.required, Validators.pattern("[0-9]{10}")]],
        address: ['', Validators.required],
        address2: ['', Validators.required],
        city: ['', Validators.required],
        provincia: ['', Validators.required],
        termsYcond: [false, Validators.required],
        password:['', [
          Validators.required,
          Validators.pattern(/^(?=\D*\d)(?=[^a-z]*[a-z])(?=[^A-Z]*[A-Z]).{8,30}$/)
        ]]
    
    });

}

onSubmit(): void{
  console.log(this.registroForm);
}
}
