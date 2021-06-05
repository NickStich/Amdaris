import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { HomeComponent } from './component/home/home.component';
import { ThirdPartyPersonService } from './service/thirdPartiesService/third-party-person.service';
import { ThirdPartyPersonFormComponent } from './component/third-parties/third-party-person-form/third-party-person-form.component';
import { AboutComponent } from './component/about/about.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { InvoicesComponent } from './component/invoice/invoices/invoices.component';
import { ThirdPartyPersonComponent } from './component/third-parties/third-party-person/third-party-person.component';
import { EditThirdPartyPersonComponent } from './component/third-parties/edit-third-party-person/edit-third-party-person.component';
import { InvoiceFormComponent } from './component/invoice/invoice-form/invoice-form.component';
import { MatTableModule } from '@angular/material/table';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatNativeDateModule } from '@angular/material/core';
import { TypePipePipe } from './component/third-parties/third-party-person/type-pipe.pipe';
import { MatSelectModule } from '@angular/material/select';
import { ReactiveFormsModule } from '@angular/forms';
import { ProductListComponent } from './component/product/product-list/product-list.component';
import { ProductFormComponent } from './component/product/product-form/product-form.component';
import { ProductEditComponent } from './component/product/product-edit/product-edit.component';
import {MatDialogModule} from '@angular/material/dialog';
import { InvoiceViewComponent } from './component/invoice/invoice-view/invoice-view.component';
import {MatMenuModule} from '@angular/material/menu';
import { InvoiceEditComponent } from './component/invoice/invoice-edit/invoice-edit.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    ThirdPartyPersonComponent,
    ThirdPartyPersonFormComponent,
    AboutComponent,
    EditThirdPartyPersonComponent,
    InvoicesComponent,
    InvoiceFormComponent,
    TypePipePipe,
    ProductListComponent,
    ProductFormComponent,
    ProductEditComponent,
    InvoiceViewComponent,
    InvoiceEditComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'tpperson', component: ThirdPartyPersonComponent },
      { path: 'tpperson/Create', component: ThirdPartyPersonFormComponent },
      { path: 'tpperson/Edit/:id', component: EditThirdPartyPersonComponent },
      { path: 'invs', component: InvoicesComponent },
      { path: 'invs/Create/:id', component: InvoiceFormComponent },
      { path: 'invs/View/:id', component: InvoiceViewComponent},
      { path: 'invs/Edit/:id', component: InvoiceEditComponent},
      { path: 'prdt' , component: ProductListComponent},
      { path: 'prdt/Create', component : ProductFormComponent},
      { path: 'prdt/Edit/:id', component: ProductEditComponent},
      { path: 'about', component: AboutComponent }
    ]),
    BrowserAnimationsModule,
    MatTableModule,
    MatDatepickerModule,
    MatFormFieldModule,
    MatInputModule,
    MatNativeDateModule,
    MatSelectModule,
    ReactiveFormsModule,
    MatDialogModule,
    MatMenuModule
  ],
  entryComponents: [InvoiceViewComponent],
  providers: [ThirdPartyPersonService],
  bootstrap: [AppComponent]
})
export class AppModule { }
