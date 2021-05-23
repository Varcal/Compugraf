import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-field-error-control',
  templateUrl: './field-error-control.component.html',
  styleUrls: ['./field-error-control.component.css']
})
export class FieldErrorControlComponent implements OnInit {
  @Input()  mostrarErro!: boolean;
  @Input()  msgErro!: string;

  constructor() { }

  ngOnInit(): void {
  }

}
