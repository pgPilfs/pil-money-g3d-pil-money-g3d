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
        name: ['', Validators.required],
        surname:['',Validators.required],
        email:new FormControl('', [Validators.required, Validators.email]),
        password: new FormControl('', [Validators.required]),
        phoneNumber: ['', Validators.required],
        phoneNumber2:['', Validators.required],
        address: ['', Validators.required],
        address2: ['', Validators.required],
        city: ['', Validators.required],
        provincias: ['', Validators.required],

        termsYcond: [false, Validators.required],
      
    
    });

}

onSubmit(): void{
  console.log(this.registroForm);
}
}
