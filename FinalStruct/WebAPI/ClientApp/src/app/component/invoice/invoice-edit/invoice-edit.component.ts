import { DatePipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormArray } from '@angular/forms';
import { FormBuilder } from '@angular/forms';
import { FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Invoice } from 'src/app/model/invoice/invoice';
import { Position } from 'src/app/model/position/position';
import { Product } from 'src/app/model/product/product';
import { ThirdPartyPerson } from 'src/app/model/thirdPartyPerson/third-party-person';
import { InvoiceService } from 'src/app/service/invoiceService/invoice.service';
import { PositionService } from 'src/app/service/positionService/position.service';
import { ProductService } from 'src/app/service/productService/product.service';
import { ThirdPartyPersonService } from 'src/app/service/thirdPartiesService/third-party-person.service';

@Component({
  selector: 'app-invoice-edit',
  templateUrl: './invoice-edit.component.html',
  styleUrls: ['./invoice-edit.component.css']
})
export class InvoiceEditComponent implements OnInit {

  invoice: Invoice;
  toBePostInvoice: Invoice;
  thirdPartyPersons: ThirdPartyPerson[] = [];
  thirdPartyPerson: ThirdPartyPerson;
  positions: Position[] = [];
  products: Product[] = [];
  invoiceForm: FormGroup;
  typeVariable: number;
  invoiceTotal: number;

  constructor(private route: ActivatedRoute,
    private router: Router,
    private invoiceService: InvoiceService,
    private tppService: ThirdPartyPersonService,
    private positionService: PositionService,
    private productService: ProductService,
    private formBuilder: FormBuilder) {
    this.invoice = new Invoice();
  }

  ngOnInit() {
    let id: number;
    id = parseInt(this.route.snapshot.paramMap.get('id'), 10);
    this.invoiceService.getJsonById(id).subscribe(data => {
      this.invoice = data;
    });
    this.invoiceForm = this.formBuilder.group({
      thirdPartyPersonId: 0,
      date: '',
      number: '',
      positions: this.formBuilder.array([this.createItem()]),
      type: 0,
      status: 0,
      vatType: 0,
      value: 0,
      vatValue: 0
    });

    console.log(this.invoice.number);
  }

  enableEdit() {
    this.invoiceForm.patchValue({
      thirdPartyPersonId: this.invoice.thirdPartyPersonId,
      date: new DatePipe('en-US').transform(this.invoice.date, 'yyyy-MM-dd'),
      number: this.invoice.number,
      status: this.invoice.status,
      vatType: this.invoice.vatType,
      value: this.invoice.value,
      vatValue: this.invoice.vatValue,
      type: this.invoice.type
    });
    this.invoiceForm.setControl('positions', this.setExistingPositions(this.invoice.positions));
  }

  setExistingPositions(positionsArray: Position[]): FormArray {
    const formArray = new FormArray([]);
    positionsArray.forEach(p => {
      formArray.push(this.formBuilder.group({
        product: this.formBuilder.group({
          name: p.product.name,
          price: p.product.price,
        }),
        quantity: p.quantity,
      }));
    });
    return formArray;
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

  // getTppById(id: number): string {
  //   let person = new ThirdPartyPerson();
  //   this.tppService.getById(id).subscribe(data => {
  //     person = data;
  //   });
  //   return person.name;
  // }

  getTppByType(type: number): ThirdPartyPerson[] {
    let persons: ThirdPartyPerson[] = [];
    this.tppService.getByType(type).subscribe(data => {
      persons = data;
    });
    return persons;
  }


  gotoInvoiceList() {
    this.router.navigate(['invs']);
  }

  onSubmit() {
    this.toBePostInvoice = this.invoiceForm.value;
    console.log(this.toBePostInvoice);
    this.invoiceService.update(this.invoice.id, this.toBePostInvoice).subscribe(result => this.gotoInvoiceList());
  }

  deleteFieldValue(index) {
    this.invoicePositions.removeAt(index);
  }

  calculateTotal(): number {
    this.positions = this.invoicePositions.value;
    let tempValue = 0;
    for (const productValue of this.positions) {
      tempValue = tempValue + (productValue.quantity * productValue.product.price);
    }
    this.positions = [];
    this.invoiceTotal = tempValue;
    return tempValue;
  }
}
