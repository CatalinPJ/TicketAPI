import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {
  DxCheckBoxModule,
  DxNumberBoxModule,
  DxSelectBoxModule,
  DxTextAreaModule,
  DxFormModule,
  DxDateBoxModule,
  DxButtonModule,
  DxHtmlEditorModule
} from 'devextreme-angular';

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    DxCheckBoxModule,
    DxNumberBoxModule,
    DxSelectBoxModule,
    DxTextAreaModule,
    DxFormModule,
    DxDateBoxModule,
    DxButtonModule,
    DxHtmlEditorModule
  ],
  exports: [
    DxCheckBoxModule,
    DxNumberBoxModule,
    DxSelectBoxModule,
    DxTextAreaModule,
    DxFormModule,
    DxDateBoxModule,
    DxButtonModule,
    DxHtmlEditorModule
  ],
})
export class DevextremeModule {}
