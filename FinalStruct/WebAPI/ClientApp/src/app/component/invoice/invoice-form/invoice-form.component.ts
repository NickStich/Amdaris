import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormBuilder, FormGroup, FormArray, FormControl, Validators } from '@angular/forms';
import { Invoice } from 'src/app/model/invoice/invoice';
import { Position } from 'src/app/model/position/position';
import { Product } from 'src/app/model/product/product';
import { ThirdPartyPerson } from 'src/app/model/thirdPartyPerson/third-party-person';
import { InvoiceService } from 'src/app/service/invoiceService/invoice.service';
import { ThirdPartyPersonService } from 'src/app/service/thirdPartiesService/third-party-person.service';

@Component({
  selector: 'app-invoice-form',
  templateUrl: './invoice-form.component.html',
  styleUrls: ['./invoice-form.component.css']
})
export class InvoiceFormComponent implements OnInit {

  private fieldArray: Array<any> = [];
  private newAttribute: any = {};
  private invoice: Invoice;
  thirdPartyPersons: ThirdPartyPerson[] = [];
  products: Product[] = [];
  thirdPartyPerson: ThirdPartyPerson;
  positions: Position[] = [];
  invoiceForm: FormGroup;
  typeVariable: number;

  constructor(private route: ActivatedRoute,
    private router: Router,
    private invoiceService: InvoiceService,
    private tppService: ThirdPartyPersonService,
    private formBuilder: FormBuilder) {
    this.invoice = new Invoice();
  }

  ngOnInit() {
    this.typeVariable = parseInt(this.route.snapshot.paramMap.get('id'), 10);
    console.log(this.typeVariable);
    this.tppService.getByType(this.typeVariable).subscribe(data => {
      this.thirdPartyPersons = data;
    });
    this.invoiceForm = this.formBuilder.group({
      thirdPartyPersonId: 0,
      date: '',
      number: '',
      positions: this.formBuilder.array([this.createItem()]),
      type: this.typeVariable
    });

    this.invoiceForm.patchValue({
      thirdPartyPersonId: 0,
      date: '',
      number: '',
      positions: [
        {
          product: {
            name: '',
            price: 0,
          },
          quantity: 0,
        }
      ],
      type: this.typeVariable
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

  onSubmit() {
    this.invoice = this.invoiceForm.value;
    this.invoiceService.save(this.invoice).subscribe(result => this.gotoInvoiceList());
  }
  gotoInvoiceList() {
    this.router.navigate(['invs']);
  }

  // list manipulation methods
  addFieldValue() {
    this.fieldArray.push(this.newAttribute);
    this.newAttribute = {};
  }
  deleteFieldValue(index) {
    this.invoicePositions.removeAt(index);
  }

  go() {
    console.log(this.thirdPartyPersons.length);
  }
}
