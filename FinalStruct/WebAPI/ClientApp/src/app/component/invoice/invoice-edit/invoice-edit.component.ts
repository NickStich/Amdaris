import { Component, OnInit } from '@angular/core';
import { FormArray } from '@angular/forms';
import { FormBuilder } from '@angular/forms';
import { FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Invoice } from 'src/app/model/invoice/invoice';
import { Position } from 'src/app/model/position/position';
import { ThirdPartyPerson } from 'src/app/model/thirdPartyPerson/third-party-person';
import { InvoiceService } from 'src/app/service/invoiceService/invoice.service';
import { ThirdPartyPersonService } from 'src/app/service/thirdPartiesService/third-party-person.service';

@Component({
  selector: 'app-invoice-edit',
  templateUrl: './invoice-edit.component.html',
  styleUrls: ['./invoice-edit.component.css']
})
export class InvoiceEditComponent implements OnInit {

  invoice: Invoice;
  thirdPartyPersons: ThirdPartyPerson[] = [];
  thirdPartyPerson: ThirdPartyPerson;
  positions: Position[] = [];
  invoiceForm: FormGroup;
  typeVariable: number;
  invoiceTotal: number;

  constructor(private route: ActivatedRoute,
    private router: Router,
    private invoiceService: InvoiceService,
    private tppService: ThirdPartyPersonService,
    private formBuilder: FormBuilder) {
      this.invoice = new Invoice();
    }

  ngOnInit() {
    let id: number;
    id = parseInt(this.route.snapshot.paramMap.get('id'), 10);
    this.invoiceService.getById(id).subscribe(data => {
      this.invoice = data;
    });
    this.typeVariable = this.invoice.type;
    this.invoiceForm = this.formBuilder.group({
      thirdPartyPersonId: 0,
      date: '',
      number: '',
      positions: this.formBuilder.array([this.createItem()]),
      type: this.typeVariable,
      status: 0,
      vatType: (this.typeVariable - 1),
      value: 0,
      vatValue: 0
    });
    this.invoiceForm.patchValue({
      thirdPartyPersonId: this.invoice.thirdPartyPersonId,
      date: '',
      number: this.invoice.number,
      positions: [
        {
          product: {
            name: '',
            price: 0,
          },
          quantity: 0,
        }
      ],
      type: this.typeVariable,
      status: 0,
      vatType: (this.typeVariable - 1),
      value: this.invoicePositions.length,
      vatValue: 0
    });

    // this.tppService.getByType(this.typeVariable).subscribe(data => {
    //   this.thirdPartyPersons = data;
    // });
    this.tppService.findAll().subscribe(data => {
      this.thirdPartyPersons = data;
    });
  }

  get invoicePositions() {
    return this.invoiceForm.get('positions') as FormArray;
  }

  createItem(): FormGroup {
    return this.formBuilder.group({
      product: this.formBuilder.group({
        name: '',
        price: 0,
      }),
      quantity: 0,
    });
  }

  addItem(): void {
    this.invoicePositions.push(this.createItem());
  }

  getTppById(id: number): string {
    let person = new ThirdPartyPerson();
    this.tppService.getById(id).subscribe(data => {
      person = data;
    });
    return person.name;
  }

  getTppByType(type: number): ThirdPartyPerson[] {
    let persons: ThirdPartyPerson[] = [];
    this.tppService.getByType(type).subscribe(data => {
      persons = data;
    });
    return persons;
  }

  check() {
    console.log(this.invoice.number);
  }

  gotoInvoiceList() {
    this.router.navigate(['invs']);
  }

  onSubmit() {
    this.invoice = this.invoiceForm.value;
    this.invoiceService.save(this.invoice).subscribe(result => this.gotoInvoiceList());
  }

  deleteFieldValue(index) {
    this.invoicePositions.removeAt(index);
  }
}
